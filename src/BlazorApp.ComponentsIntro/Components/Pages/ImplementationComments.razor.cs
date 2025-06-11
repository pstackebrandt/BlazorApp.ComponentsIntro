using Microsoft.AspNetCore.Components;

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

    /// <summary>
    /// The text displayed on the toggle button (e.g., "Implementation Notes").
    /// </summary>
    [Parameter]
    public string ButtonText { get; set; } = "Implementation Notes";

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
    public int MinRows { get; set; } = 4;

    /// <summary>
    /// Maximum number of rows for the textarea.
    /// </summary>
    [Parameter]
    public int MaxRows { get; set; } = 15;

    /// <summary>
    /// Average characters per line used for calculating dynamic height.
    /// </summary>
    [Parameter]
    public int CharsPerLine { get; set; } = 65;

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
    /// Initializes the component with default content and visibility state.
    /// </summary>
    protected override void OnInitialized()
    {
        currentComments = DefaultContent;
        showComments = InitiallyVisible;
    }

    /// <summary>
    /// Toggles the visibility of the comments section.
    /// </summary>
    private void ToggleComments()
    {
        showComments = !showComments;
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