using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _points;   //Удали [SerializeField] и расскаментируvoid Start, тогда можно не вручную устанавливать путь
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
    //[SerializeField] private Transform _path;
    //[SerializeField] private float _speed;

    //[SerializeField] private Transform[] _points;   //Удали [SerializeField] и расскаментируvoid Start, тогда можно не вручную устанавливать путь
    //private int _currentPoint;

    ////private Rigidbody2D phisic;
    ////public Transform player;
    ////public float speed;
    ////public float agroDistance;

    //void Start()
    //{
    //    //phisic = GetComponent<Rigidbody2D>();

    //    _points = new Transform[_path.childCount];

    //    for (int i = 0; i < _path.childCount; i++)
    //    {
    //        _points[i] = _path.GetChild(i);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Transform target = _points[_currentPoint];
    //    transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

    //    //float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    //    if (transform.position == target.position)
    //    {
    //        _currentPoint++;
    //        if (_currentPoint >= _points.Length)
    //        {
    //            _currentPoint = 0;

    //            //if (distanceToPlayer < agroDistance)
    //            //{
    //            //    StartHunting();
    //            //}
    //        }
    //    }

    //    //if (distanceToPlayer < agroDistance)
    //    //{
    //    //    StartHunting();
    //    //}
    //    //else
    //    //{
    //    //    StopHunting();
    //    //}
    //}
    ////void StartHunting()
    ////{
    ////    if (player.position.x < transform.position.x)
    ////    {
    ////        phisic.velocity = new Vector2(-speed, 0);
    ////    }
    ////    else if (player.position.x > transform.position.x)
    ////    {
    ////        phisic.velocity = new Vector2(speed, 0);
    ////    }
    ////}
}