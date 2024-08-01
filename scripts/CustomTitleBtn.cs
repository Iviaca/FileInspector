using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class CustomTitleBtn : Button
{
    Button btn;

    [Export]
    public int i;

    [Export(PropertyHint.Enum, "QuitApp,MinimizeApp")]
    public string methodName = "";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        btn = this;
        btn.FocusMode = FocusModeEnum.None;

        btn.Connect(Button.SignalName.Pressed, new Callable(this, methodName));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void QuitApp()
    {
        this.GetTree().Quit();
    }

    public void MinimizeApp()
    {
        this.GetTree().Root.Mode = Window.ModeEnum.Minimized;
    }
}
