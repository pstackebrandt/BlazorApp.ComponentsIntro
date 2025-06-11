using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorApp.ComponentsIntro.Components.Pages;

/// <summary>
/// A reusable Blazor component for displaying toggleable implementation 
/// and design comments with customizable content and styling.
/// </summary>
public partial class ImplementationComments : ComponentBase
{
    private bool showComments = false;
    private string currentComments = string.Empty;
    private string textareaId = $"comments_{Guid.NewGuid():N}";
    private string modalId = $"modal_{Guid.NewGuid():N}";
    private string dragHandleId = $"dragHandle_{Guid.NewGuid():N}";
    
    // Drag functionality variables
    private bool isDragging = false;
    private double offsetX = 0;
    private double offsetY = 0;

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    /// <summary>
    /// The icon displayed on the toggle button. Supports Unicode, Bootstrap icons, 
    /// or Font Awesome classes.
    /// </summary>
    [Parameter]
    public string ButtonIcon { get; set; } = "🔧";

    /// <summary>
    /// The size of the button icon using Bootstrap font-size classes.
    /// Options: fs-6 (small), fs-5 (default), fs-4 (larger), fs-3 (large), fs-2 (very large), fs-1 (huge)
    /// </summary>
    [Parameter]
    public string IconSize { get; set; } = "fs-5";

    /// <summary>
    /// The size of the button using Bootstrap button size classes.
    /// Options: btn-sm (small), empty string (normal), btn-lg (large)
    /// </summary>
    [Parameter]
    public string ButtonSize { get; set; } = "";

    /// <summary>
    /// The text displayed on the toggle button and in tooltips 
    /// (e.g., "Implementation Notes").
    /// </summary>
    [Parameter]
    public string ButtonText { get; set; } = "Implementation Notes";

    /// <summary>
    /// Whether to show the button text alongside the icon. 
    /// If false, only the icon is shown with text in tooltip.
    /// </summary>
    [Parameter]
    public bool ShowButtonText { get; set; } = false;

    /// <summary>
    /// The label text displayed above the textarea when visible.
    /// </summary>
    [Parameter]
    public string LabelText { get; set; } = "Design & Implementation Comments:";

    /// <summary>
    /// Placeholder text shown in the empty textarea.
    /// </summary>
    [Parameter]
    public string Placeholder { get; set; } = 
        "Add your thoughts about the component design and implementation...";

    /// <summary>
    /// Default content to populate the textarea with.
    /// </summary>
    [Parameter]
    public string DefaultContent { get; set; } = string.Empty;

    /// <summary>
    /// Minimum number of rows for the textarea.
    /// </summary>
    [Parameter]
    public int MinRows { get; set; } = 8;

    /// <summary>
    /// Maximum number of rows for the textarea.
    /// </summary>
    [Parameter]
    public int MaxRows { get; set; } = 20;

    /// <summary>
    /// Average characters per line used for calculating dynamic height.
    /// </summary>
    [Parameter]
    public int CharsPerLine { get; set; } = 65;

    /// <summary>
    /// The padding of the button using Bootstrap padding classes.
    /// Options: px-1 (very tight), px-2 (tight), px-3 (normal), etc.
    /// </summary>
    [Parameter]
    public string ButtonPadding { get; set; } = "p-1";

    /// <summary>
    /// Additional CSS classes to apply to the toggle button.
    /// </summary>
    [Parameter]
    public string CssClass { get; set; } = string.Empty;

    /// <summary>
    /// Whether the comments section should be initially visible.
    /// </summary>
    [Parameter]
    public bool InitiallyVisible { get; set; } = false;

    /// <summary>
    /// Gets the calculated number of rows based on content length.
    /// </summary>
    private int CalculatedRows => CalculateOptimalRows();

    /// <summary>
    /// Gets the tooltip text showing the current state and action.
    /// </summary>
    private string TooltipText => showComments ? $"Hide {ButtonText}" : $"Show {ButtonText}";

    /// <summary>
    /// Initializes the component with default content and visibility state.
    /// </summary>
    protected override void OnInitialized()
    {
        currentComments = DefaultContent;
        showComments = InitiallyVisible;
    }

    /// <summary>
    /// Toggles the visibility of the comments section and initializes drag functionality.
    /// </summary>
    private async Task ToggleComments()
    {
        showComments = !showComments;
        
        if (showComments)
        {
            // Small delay to ensure DOM is updated
            await Task.Delay(10);
            try
            {
                await JSRuntime.InvokeVoidAsync("makeDraggable", modalId);
            }
            catch (Exception ex)
            {
                // Handle JS interop errors gracefully
                Console.WriteLine($"Error initializing drag functionality: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Calculates the optimal number of textarea rows based on content length.
    /// Takes into account line breaks and average characters per line.
    /// </summary>
    /// <returns>Number of rows between MinRows and MaxRows</returns>
    private int CalculateOptimalRows()
    {
        if (string.IsNullOrEmpty(currentComments))
            return MinRows;

        // Count explicit line breaks
        int lineBreaks = currentComments.Count(c => c == '\n') + 1;
        
        // Calculate rows needed based on character count and average line length
        int charBasedRows = (int)Math.Ceiling((double)currentComments.Length / CharsPerLine);
        
        // Use the larger of the two calculations
        int calculatedRows = Math.Max(lineBreaks, charBasedRows);
        
        // Ensure result is within min/max bounds
        return Math.Max(MinRows, Math.Min(MaxRows, calculatedRows));
    }
} 