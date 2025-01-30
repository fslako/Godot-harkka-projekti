using Godot;
using System;

public partial class Snake : Node2D
{
	[Export] float _Nopeus;

	public void Move()
	{
		Vector2 _inputDirection = Input.GetVector("left", "right", "up", "down");
		Position += _inputDirection * _Nopeus;
	}
	public override void _Input(InputEvent @event)
	{
		GD.Print(@event.AsText());
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Move();
	}




}
