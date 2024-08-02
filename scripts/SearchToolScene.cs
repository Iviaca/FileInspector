using FileInspectPort;
using FileViewPort;
using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public partial class SearchToolScene : BoxContainer
{
    [Export]
    public CheckButton SearchBtn { get; set; }

    [Export]
    public CheckButton NameSearchBtn { get; set; }

    [Export]
    public LineEdit DirPathLineEdt { get; set; }

    [Export]
    public HBoxContainer UpperControlHContainer { get; set; }

    [Export]
    public Label WarningLbl { get; set; }

    private List<BaseButton> SearchModeCheckBtnList = new();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var Childlist = UpperControlHContainer.GetChildren();
        foreach (var child in Childlist)
        {
            if (child is CheckButton controlNode)
            {
                if (controlNode.GetType().GetProperty("FocusMode") is not null)
                    controlNode.FocusMode = FocusModeEnum.None;
            }
        }

        SearchModeCheckBtnList.Add(SearchBtn);
        SearchModeCheckBtnList.Add(NameSearchBtn);
        SwitchAllButtons(SearchModeCheckBtnList, true);//disable search mode selection

        SearchBtn.Connect(CheckButton.SignalName.Toggled, new Callable(this, MethodName.OnChangeSearchModeToSearch));
        NameSearchBtn.Connect(CheckButton.SignalName.Toggled, new Callable(this, MethodName.OnChangeSearchModeToNameSearch));
        DirPathLineEdt.Connect(LineEdit.SignalName.TextChanged, new Callable(this, MethodName.OnPathChanged));
        DirPathLineEdt.Connect(LineEdit.SignalName.TextSubmitted, new Callable(this, MethodName.OnPathSubmitted));

        //initialize inspector
        //FileInspector fi = null;
        //FileNameInspector fni = null;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }

    private void ChangePath(string path)
    {
        DirPathLineEdt.Text = path;
        DirPathLineEdt.EmitSignal(LineEdit.SignalName.TextChanged, path);
    }

    public void OnChangeSearchModeToSearch(bool isToggled)
    {
        if (string.IsNullOrEmpty(DirPathLineEdt.Text))
        {
            GD.Print(1, isToggled);
            if (isToggled)
            {
                NameSearchBtn.ButtonPressed = false;
            }
        }
    }

    public void OnChangeSearchModeToNameSearch(bool isNameToggled)
    {
        if (string.IsNullOrEmpty(DirPathLineEdt.Text))
        {
            GD.Print(2, isNameToggled);
            if (isNameToggled)
            {
                SearchBtn.ButtonPressed = false;
            }
        }
    }

    public void OnPathChanged(string path)
    {
        WarningLbl.Visible = false;
        SwitchAllButtons(SearchModeCheckBtnList, false);

    }

    public void OnPathSubmitted(string path)
    {
        if (!string.IsNullOrEmpty(path))
        {
            if (!Directory.Exists(path))
            {
                WarningLbl.Text = $"Check that '{path}' exists.";
                WarningLbl.Visible = true;
            }
        }
        else
        {
            WarningLbl.Text = "Check that a non-empty path is designated.";
            WarningLbl.Visible = true;
        }
    }

    /// <summary>
    /// change if the button is clickable
    /// </summary>
    /// <param name="btns"></param>
    /// <param name="disabled">true for disable, false for enable</param>
    public void SwitchAllButtons(List<BaseButton> btns, bool disabled)
    {
        foreach (BaseButton btn in btns)
        {
            btn.Disabled = disabled;
        }
    }
}
