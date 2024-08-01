using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class CustomTitleCheckBtn : CheckButton
{
    CheckButton cBtn;

    //string1

    //string2



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cBtn = this;
        cBtn.FocusMode = FocusModeEnum.None;

        //btn.Connect(Button.SignalName.Pressed, new Callable(this, methodName));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void ChangeDarkMode()
    {

    }

    public void ChangeLightMode()
    {

    }
}
