using System;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.ComponentsIntro.Components.Pages;

/// <summary>
/// A reusable Blazor component that displays a dismissible alert message.
/// The alert can be shown or hidden and allows custom content through 
/// child components.
/// </summary>
public partial class DismissibleAlert
{
    /// <summary>
    /// Gets or sets whether the alert is currently visible.
    /// Defaults to true (visible) when the component is created.
    /// </summary>
    [Parameter]
    public bool Show { get; set; } = true;

    /// <summary>
    /// Gets or sets the content to be displayed inside the alert.
    /// This allows for flexible content including text, HTML, or other
    /// Blazor components to be rendered within the alert.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Dismisses the alert by setting the Show property to false.
    /// This method can be called from the component's UI or externally
    /// to hide the alert from view.
    /// </summary>
    public void Dismiss() => Show = false;
}
