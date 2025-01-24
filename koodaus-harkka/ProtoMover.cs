using Godot;
using System;

namespace Snakegame
{
public partial class ProtoMover : Node2D
{
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
		GlobalPosition += Vector2.Down;
	}
}
}