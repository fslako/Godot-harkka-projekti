using Godot;
using System;

public partial class NewScript : Node
{
    int a = 0, b = 1, temp;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Hello World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(a);

        	temp = a;
      	    a = b;
       	   	b = temp + b;
	}
}
