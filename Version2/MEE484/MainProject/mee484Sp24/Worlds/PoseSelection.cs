using Godot;
using System;

public partial class PoseSelection : OptionButton
{
	Control DropDown;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DropDown = GetNode<OptionButton>("PoseSelection");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
