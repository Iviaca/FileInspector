using Godot;
using System;

public partial class MainWindow : Node
{
	// Called when the node enters the scene tree for the first time.
	Node node;

	public override void _Ready()
	{
		node = GetNode<Node>("/root/MainApp");
		node.GetWindow().Transparent = true;
		node.GetViewport().TransparentBg = true;
		


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
