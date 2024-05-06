using Godot;
using System;

public partial class YBotModel : Node3D
{

	Skeleton3D skel;
	MannequinScene mquinScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mquinScene = GetParent<MannequinScene>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
