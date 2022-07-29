using Godot;
using System;

public class Player : KinematicBody2D
{

    Vector2 velocity = new Vector2(0, 0);
    private const int Speed = 350;
    private const int Gravity = 35;
    private const int JumpForce = -1100;

    private AnimatedSprite animatedSprite;

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
    }
    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("right"))
        {
            velocity.x = Speed;
            animatedSprite.Play("walk");
            animatedSprite.FlipH = false;
            
        }
        else if (Input.IsActionPressed("left"))
        {
            velocity.x = -Speed;
            animatedSprite.Play("walk");
            animatedSprite.FlipH = true;

        }
        else {
            animatedSprite.Play("idle");
        }

        if (!(IsOnFloor())) {
            animatedSprite.Play("air");
        }
        velocity.y = velocity.y + Gravity;

        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
			velocity.y = JumpForce;
        }



        // Moves the character by the passed velocity value, also handles collisions
        velocity = MoveAndSlide(velocity, Vector2.Up);

        /* Makes the character go to the 2nd value, the 3rd value controls how fast it reaches that value. 
		The higher the value, the faster the character stops. */
        velocity.x = Lerp(velocity.x, 0, (float)0.2);
    }

    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
    Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
    {
        float retX = Lerp(firstVector.x, secondVector.x, by);
        float retY = Lerp(firstVector.y, secondVector.y, by);
        return new Vector2(retX, retY);
    }
}
