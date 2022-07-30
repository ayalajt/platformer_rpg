using Godot;
using System;

public class HUD : CanvasLayer
{

    private Label HP;
    private Label MP;
    private KinematicBody2D player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HP = GetNode<Label>("HP");
        MP = GetNode<Label>("MP");
        player = GetParent().GetNode<KinematicBody2D>("Player");

        int currentHP = (int) player.Call("getHealth");
        int maxHP = (int) player.Call("getMaxHealth");
        String health = currentHP.ToString() + "/" + maxHP.ToString();
        HP.Text = health;

        int currentMP = (int) player.Call("getMagic");
        int maxMP = (int) player.Call("getMaxMagic");
        String magic = currentMP.ToString() + "/" + maxMP.ToString();
        MP.Text = magic;


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
