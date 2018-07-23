using System;
using Microsoft.Bot.Builder.FormFlow;

public enum AutoOptions { Accept = 1, Decline, Other_options };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class MovieScript9
{
    [Prompt("Your booking behavior has changed over the last days. Based on your previous bookings, there is a more accurate forecast available for you. {||}")]
    public AutoOptions Main { get; set; }

    public static IForm<MovieScript9> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<MovieScript9>().Build();
    }

    public static IFormDialog<MovieScript9> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
