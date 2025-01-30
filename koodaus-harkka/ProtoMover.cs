using Godot;
using System;

namespace Snakegame
{
public partial class ProtoMover : Node2D
{
	[Export] private float _x;
	[Export] private float _y;
	[Export] private float _speed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print($"Lokaali sijainti: {Position}");
		GD.Print($"Globaali sijainti: {GlobalPosition}");
		GlobalPosition = new Vector2(100, 100);
		GD.Print($"Lokaali sijainti: {Position}");
		GD.Print($"Globaali sijainti: {GlobalPosition}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 icon = new Vector2(_x, _y);
		GlobalPosition += icon * (float)delta * _speed;

	}
}
}