using Godot;
using System;

namespace SnakeGame
{
	public partial class Snake : Node2D
	{
		// Enum on integer, jonka arvot ovat nimetty.
		public enum Direction
		{
			None = 0,
			Up,
			Down,
			Left,
			Right,
		}

		[Export] private float _speed = 1;
		[Export] private Grid _grid = null;
		private Vector2I _currentPosition = new Vector2I(5,5);

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			if (_grid.GetWorldPosition(_currentPosition, out Vector2 worldPosition))
			{
				Position = worldPosition;
			}
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			Direction direction = ReadInput();
			Move(direction);
		}

		private void Move(Direction direction)
		{
			Vector2I nextPosition = GetNextGridPosition(direction, _currentPosition);
			if (_grid.GetWorldPosition(nextPosition, out Vector2 worldPosition))
			{
				_currentPosition = nextPosition;
				Position = worldPosition;
			}
		}

		private void Move(Direction direction, float delta)
		{
			Vector2 directionVector = GetDirectionVector(direction);
			Translate(directionVector * _speed * delta);
		}

		private Vector2I GetNextGridPosition(Direction direction, Vector2I currentPosition)
		{
			switch (direction)
			{
				case Direction.Up: return currentPosition + Vector2I.Up;
				case Direction.Down: return currentPosition + Vector2I.Down;
				case Direction.Right: return currentPosition + Vector2I.Right;
				case Direction.Left: return currentPosition + Vector2I.Left;
				default: return currentPosition;
			}
		}

		private Vector2 GetDirectionVector(Direction direction)
		{
			switch (direction)
			{
				case Direction.Up: return Vector2.Up;
				case Direction.Down: return Vector2.Down;
				case Direction.Right: return Vector2.Right;
				case Direction.Left: return Vector2.Left;
				default: return Vector2.Zero; // Mikä tahansa muu case.
			}
		}

		private Direction ReadInput()
		{
			Direction direction = Direction.None;

			if (Input.IsActionJustPressed(Config.MoveUpAction))
			{
				direction = Direction.Up;
			}
			else if (Input.IsActionJustPressed(Config.MoveDownAction))
			{
				direction = Direction.Down;
			}
			else if (Input.IsActionJustPressed(Config.MoveLeftAction))
			{
				direction = Direction.Left;
			}
			else if (Input.IsActionJustPressed(Config.MoveRightAction))
			{
				direction = Direction.Right;
			}

			return direction;
		}
	}
}