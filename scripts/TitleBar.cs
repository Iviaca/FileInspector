using Godot;
using System;

public partial class TitleBar : Panel
{

    bool isDragging = false;
    Vector2I mouseStartPosition = new Vector2I(0, 0);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Connect(Panel.SignalName.GuiInput, new Callable(this, MethodName.OnGuiInput));
        //this.Connect(Panel.SignalName.MouseExited, new Callable(this, MethodName.OnExitArea));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (isDragging)
        {
            Vector2I mouseDelta = (Vector2I)GetViewport().GetMousePosition() - mouseStartPosition;
            GetWindow().Position += mouseDelta;
        }
    }


    //public override void _GuiInput(InputEvent @event)
    //{


    //}

    public void OnGuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseHoldingBtn) //Use InputEventMouseButton instead of using InputEventMouse
        {
            if (mouseHoldingBtn.ButtonIndex == MouseButton.Left)
            {
                if (!isDragging)
                {
                    mouseStartPosition = (Vector2I)GetViewport().GetMousePosition();
                }

                isDragging = mouseHoldingBtn.IsPressed();
            }
        }
    }

}
