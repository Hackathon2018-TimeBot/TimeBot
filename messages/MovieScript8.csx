using System;
using Microsoft.Bot.Builder.FormFlow;

public enum MainOptions8 { Forecast = 1, Booking, Performance };
public enum AdjustmentOptions8 { BDA_PowerApps_implementation = 1, Project_not_listed, Other_options };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class MovieScript8
{
    [Prompt("How can I help you? {||}")]
    public MainOptions8 Main { get; set; }

    [Prompt("I have noticed that you are in Berlin today. You can add one of your recent projects from that area to your forecast: {||}")]
    public AdjustmentOptions8 Adjustment { get; set; }

    [Prompt("How many hours do you want to forecast for today? ")]
    public int Hours8 { get; set; }

    public static IForm<MovieScript8> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<MovieScript8>().Build();
    }

    public static IFormDialog<MovieScript8> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
