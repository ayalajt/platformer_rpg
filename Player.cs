using Godot;
using System;

public class Player : KinematicBody2D
{

    Vector2 velocity = new Vector2(0, 0);

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("right"))
        {
            velocity.x = 100;
        }
        if (Input.IsActionPressed("left"))
        {
            velocity.x = -100;
        }

		// Moves the character by the passed velocity value
        MoveAndSlide(velocity);

		/* Makes the character go to the 2nd value, the 3rd value controls how fast it reaches that value. 
		The higher the value, the faster the character stops. */
        velocity.x = Lerp(velocity.x, 0, (float) 0.2);
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
