using Godot;
using System;

public class EnemySlime : KinematicBody2D
{
    Vector2 velocity = new Vector2(0, 0);
    private AnimatedSprite animatedSprite;
    [Export]
    int direction = -1;
    private const int Gravity = 35;
    private const int Speed = 50;



    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        if (direction == 1)
        {
            animatedSprite.FlipH = true;
        }
        else if (direction == 1)
        {
            animatedSprite.FlipH = false;
        }
    }
    public override void _PhysicsProcess(float delta)
    {

        if (direction == 1)
        {
            animatedSprite.FlipH = true;
        }
        else if (direction == 1)
        {
            animatedSprite.FlipH = false;
        }

        if (IsOnWall())
        {
            direction = direction * -1;
        }

        velocity.y = velocity.y + Gravity;
        velocity.x = Speed * direction;

        velocity = MoveAndSlide(velocity, Vector2.Up);
    }
}
