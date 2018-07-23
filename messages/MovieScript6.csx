using System;
using Microsoft.Bot.Builder.FormFlow;

public enum MainOptions { Forecast = 1, Booking, Performance };
public enum AdjustmentOptions { DFG_Addin_Development_4h = 1, Bosch_Learning_Portal_4h, Add_a_project, Submit_without_adjustment };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class MovieScript6
{
    [Prompt("How can I help you? {||}")]
    public MainOptions Main { get; set; }

    [Prompt("Your billable hours for today will be submitted. Do you want to adjust them: {||}")]
    public AdjustmentOptions Adjustment { get; set; }

    public static IForm<MovieScript6> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<MovieScript6>().Build();
    }

    public static IFormDialog<MovieScript6> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
