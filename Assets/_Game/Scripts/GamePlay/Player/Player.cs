using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rd;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform avatar;
    [SerializeField] private Transform directTF;

    [SerializeField] WeaponBase currentWeapon;
    private string animName;

    private List<Character> targets = new List<Character>();
    private Character target; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direct = new Vector2 (horizontal, vertical);
        
        ChangeDirect(direct);
        MoveDirect(direct);
        UpdateTarget();

        OnAttack();
    }

    #region Control
    public void ChangeDirect(Vector2 direct)
    {
        if(direct.sqrMagnitude > 0.1f)
        {
            ChangeAnim(Constant.ANIM_RUN);
            if(direct.x != 0)
            {
                ChangeFacing(direct.x > 0);
            }

            directTF.up = direct;
        }
        else
        {
            ChangeAnim(Constant.ANIM_IDLE);
        }
    }

    public void MoveDirect(Vector2 direct) 
    {
        rd.velocity = direct * moveSpeed;
    }

    public void ChangeAnim(string animName)
    {
        if (this.animName != animName)
        {
            animator.ResetTrigger(this.animName);
            this.animName = animName;
            animator.SetTrigger(this.animName);
        }
    }

    private void ChangeFacing(bool isRight)
    {
        avatar.localRotation = isRight ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);
    }
    #endregion

    #region Gun
    public void OnAttack()
    {
        currentWeapon.OnAttack();
    }


    private void UpdateTarget()
    {
        target = GetTargetNearest();

        currentWeapon.SetTarget(target == null ? (directTF.up + transform.position) : (target.transform.position));
    }

    public void AddTarget(Character c)
    {
        targets.Add(c);
    }

    public void RemoveTarget(Character c)
    {
        targets.Remove(c);
    }

    private Character GetTargetNearest()
    {
        Character c = null;
        if (targets.Count > 0)
        {
            c = targets[0];
            float distancce = Vector2.Distance(c.transform.position, transform.position);
            for (int i = 1; i < targets.Count; i++)
            {
                float dis = Vector2.Distance(targets[i].transform.position, transform.position);
                if (dis < distancce)
                {
                    distancce = dis;
                    c = targets[i];
                }
            }
        }
        return c;
    }
    #endregion
}
