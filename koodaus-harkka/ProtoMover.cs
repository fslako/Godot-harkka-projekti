using Godot;
using System;

namespace Snakegame
{
public partial class ProtoMover : Node2D
{
	[Export] private bool _mode;
	[Export] private float _x;
	[Export] private float _y;
	[Export] private float _speed;
	private Vector2 _target1 = new Vector2(200,200);
	private Vector2 _target2 = new Vector2(1000,200);
	private bool _suunta;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		if (_mode == true) {
			GlobalPosition = new Vector2(200,200);
		} else {
			GlobalPosition = new Vector2(100,100);
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (Position.DistanceTo(_target1) < 10)
		{
			_suunta = true;
		} else if (Position.DistanceTo(_target2) < 10)
		{
			_suunta = false;
		}

		if (_mode == true && _suunta == true) {
			Position += Position.DirectionTo(_target2) * (float)delta * _speed;
		} else if (_mode == true && _suunta == false) {
			Position += Position.DirectionTo(_target1) * (float)delta * _speed;
		} else {
			Vector2 icon = new Vector2(_x, _y);
			GlobalPosition += icon * (float)delta * _speed;
		}

	}
}
}