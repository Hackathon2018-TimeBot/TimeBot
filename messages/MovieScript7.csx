using System;
using Microsoft.Bot.Builder.FormFlow;

public enum MainOptions7 { Forecast = 1, Booking, Performance };
public enum AdjustmentOptions7 { DFG_Addin_Development_4h = 1, Bosch_Learning_Portal_4h, Add_a_project, Submit_without_adjustment };
public enum AdjustedOptions1 { DFG_Addin_Development_8h = 1, Bosch_Learning_Portal_4h, Add_a_project, No_adjustment };
public enum AdjustedOptions2 { DFG_Addin_Development_8h = 1, Add_a_project, No_adjustment };
public enum AddProjectOptions { Zeiss_Vacation_Flow_2h = 1, Porsche_Stream_Video_4h, Project_not_listed, No_adjustment };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class MovieScript7
{
    [Prompt("How can I help you? {||}")]
    public MainOptions7 Subject { get; set; }

    [Prompt("This is your forecast for today. Select a project if you want to adjust it: {||}")]
    public AdjustmentOptions7 Adjustment1 { get; set; }

    [Prompt("How many hours do you want to forecast for today? ")]
    public int Hours1 { get; set; }

    [Prompt("Your forecast has been updated. Select another project if you want to adjust it: {||}")]
    public AdjustedOptions1 Adjustment2 { get; set; }

    [Prompt("How many hours do you want to forecast for today? ")]
    public int Hours2 { get; set; }

    [Prompt("Your forecast has been updated. Select another project if you want to adjust it: {||}")]
    public AdjustedOptions2 Adjustment3 { get; set; }

    [Prompt("Based on your work today in Office365, I recommend to add the following projects for today: {||}")]
    public AddProjectOptions AddProject { get; set; }

    public static IForm<MovieScript7> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<MovieScript7>().Build();
    }

    public static IFormDialog<MovieScript7> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
