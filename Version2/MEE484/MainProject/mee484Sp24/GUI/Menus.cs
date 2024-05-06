using Godot;
using System;

public partial class Menus : Control
{
	OptionButton ModelSelection;
    OptionButton PoseSelection;
    OptionButton AngleSelection;
    Node3D model;
    CharacterItf  modelItf;
    MannequinScene mScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		//Grabs the option button nodes
        ModelSelection = GetNode<OptionButton>("ModelsOption");
        PoseSelection = GetNode<OptionButton>("PosesOption");
        AngleSelection = GetNode<OptionButton>("AngleOption");

        //Add options to the models menu
        ModelSelection.AddItem("X Bot",0);
        ModelSelection.AddItem("Y Bot",1);
        ModelSelection.AddItem("Gymnast",2);
        //ModelSelection.selected = 0;

        //Add options to poses menu
        PoseSelection.AddItem("Save");
        PoseSelection.AddItem("Edit");

        //Add options to angles menu
        AngleSelection.AddItem("X angle");
        AngleSelection.AddItem("Y angle");
        AngleSelection.AddItem("Z angle");

        //Reference of MannequinScene script
		mScene=GetParent().GetParent().GetParent<MannequinScene>();

        //Connect the item selected signal to a method
        ModelSelection.ItemSelected += ChosenModel;
	}
        private void ChosenModel(long ii)
        {
            var text = ModelSelection.GetItemText(ModelSelection.Selected);
            GD.Print("Current Model = " + text);

            mScene.OnChangeModel(ii);
      
			// when new models are created, add them to the list

            // // 0 = X Bot
            // if(ii == 0){
		    // model = GetNode<Node3D>("XBotModel");
		    // modelItf = new MixamoItf(model);
            // }
            // // 1 = Y Bot
            // if(ii == 1){
		    // model = GetNode<Node3D>("YBotModel");
		    // modelItf = new MixamoItf(model);
            // }
            // // 2 = Gymnast
            // if (ii == 2){
		    // model = GetNode<Node3D>("GymBlockModel");
		    // modelItf = new GymBlockItf(model);
            // }
		}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
