#load "MovieScript6.csx"
#load "MovieScript7.csx"
#load "MovieScript8.csx"
#load "MovieScript9.csx"

using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

/// This dialog is the main bot dialog, which will call the Form Dialog and handle the results
[Serializable]
public class MainDialog : IDialog<object>
{
    static string _dialog;

    public MainDialog(string dialog)
    {
        if (dialog == "Dialog6" || dialog == "Dialog7" || dialog == "Dialog8" || dialog == "Dialog9")
        {
            _dialog = dialog;
        }
        else  
        {
            _dialog = "Dialog6";
        }
    }

    public Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedAsync);
        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
        if (_dialog == "Dialog6")     
        {
            context.Call(MovieScript6.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
        }
        else if (_dialog == "Dialog7")
        {
            context.Call(MovieScript7.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
        }
        else if (_dialog == "Dialog8")
        {
            context.Call(MovieScript8.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
        }
        else if (_dialog == "Dialog9")
        {
            context.Call(MovieScript9.BuildFormDialog(FormOptions.PromptInStart), FormComplete);
        }
        
    }

    private async Task FormComplete(IDialogContext context, IAwaitable<object> result)
    {
        try
        {
            var form = await result;
            if (form != null)
            {
                await context.PostAsync("Thank you! Your records have been updated.");
            }
            else
            {
                await context.PostAsync("Form returned empty response! Type anything to restart it.");
            }
        }
        catch (OperationCanceledException)
        {
            await context.PostAsync("You canceled the form! Type anything to restart it.");
        }

        context.Wait(MessageReceivedAsync);
    }
}