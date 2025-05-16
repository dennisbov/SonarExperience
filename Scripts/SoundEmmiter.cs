using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEmmiter : MonoBehaviour
{
     private int _raysNumber;
     private float _raysLenth;
    [SerializeField] private GameObject _intersectionMarkPref;
     private float _showcaseDuration;
    [SerializeField] private LayerAssosiationsList _layerList;
    [SerializeField] private int _marksMaxNumber = 500;
     private float _distanceModifier;

    private struct Mark
    {
        public Vector2 Position;
        public LayerMask Layer;
        public float Power;
        public bool isAvaliable;

        public Mark(Vector2 Position, LayerMask Layer, float Power)
        {
            this.Position = Position;
            this.Layer = Layer;
            this.Power = Power;
            this.isAvaliable = true;
        }
    }

    public void EmmitSound(EmmitingSoundInfo soundInfo)
    {
        _raysNumber = soundInfo.RaysNumber;
        _raysLenth = soundInfo.RaysLenth;
        _distanceModifier = soundInfo.DistantModifier;
        _showcaseDuration = soundInfo.ShowcaseDuration;
        Mark[] interseptionPoints = new Mark[_marksMaxNumber];
        if (soundInfo.IsPiercingRays)
            interseptionPoints = CalculateInterseptionPiercingPoints(transform.position);
        else
            interseptionPoints = CalculateInterseptionPoints(transform.position);
        StartCoroutine(InterseptionsShowcase(interseptionPoints, transform.position));
    }

    private Mark[] CalculateInterseptionPoints(Vector2 centerPoint)
    {
        float currentRayAngle = 0;
        float deltaAngle = 2 * Mathf.PI / _raysNumber;
        Vector2 currentRayDirection;
        List<Mark> result = new List<Mark>(_raysNumber);
        Mark mark = new Mark();

        for (int i = 0; i < _raysNumber; i++)
        {
            currentRayDirection = new Vector2(Mathf.Cos(currentRayAngle), Mathf.Sin(currentRayAngle));
            RaycastHit2D hit = Physics2D.Raycast(centerPoint, currentRayDirection, _raysLenth);

            if (hit)
            {
                mark = new Mark(
                    hit.point,
                    hit.transform.gameObject.layer,
                    Mathf.Clamp01((1 - (hit.distance / _raysLenth)) * _distanceModifier));
                result.Add(mark);
            }
            currentRayAngle += deltaAngle;
        }
        return result.ToArray();
    }

    private Mark[] CalculateInterseptionPiercingPoints(Vector2 centerPoint)
    {
        float currentRayAngle = 0;
        float deltaAngle = 2 * Mathf.PI / _raysNumber;
        Vector2 currentRayDirection;
        List<Mark> result = new List<Mark>(_raysNumber);
        Mark mark = new Mark();

        for (int i = 0; i < _raysNumber; i++)
        {
            currentRayDirection = new Vector2(Mathf.Cos(currentRayAngle), Mathf.Sin(currentRayAngle));
            ContactFilter2D contactFilter = new ContactFilter2D();
            List<RaycastHit2D> hitPoints = new List<RaycastHit2D>();
            int hitNumber = Physics2D.Raycast(centerPoint, currentRayDirection, contactFilter.NoFilter(), hitPoints, _raysLenth);

            for (int j = 0; j < hitNumber; j++)
            {
                RaycastHit2D hit = hitPoints[j];

                if (hit)
                {
                    mark = new Mark(
                        hit.point,
                        hit.transform.gameObject.layer,
                        Mathf.Clamp01((1 - (hit.distance / _raysLenth)) * _distanceModifier));
                    result.Add(mark);
                }
            }       
            currentRayAngle += deltaAngle;
        }
        return result.ToArray();
    }

    private IEnumerator InterseptionsShowcase(Mark[] interseptions, Vector2 center)
    {
        float expiredTime = 0;
        while (expiredTime < _showcaseDuration)
        {
            for(int i = 0; i < interseptions.Length; i++)
            {
                if(interseptions[i].isAvaliable && Vector2.Distance(interseptions[i].Position, center) < (expiredTime / _showcaseDuration * _raysLenth))
                {
                    SpawnMark(interseptions[i]);
                    interseptions[i].isAvaliable = false;
                }
            }
            expiredTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private void SpawnMark(Mark mark)
    {
        GameObject expectedPrefab = _layerList.Default.MarkerPref;
        foreach (LayerToColour i in _layerList.list)
        {
            if(i.Layer == mark.Layer.value)
            {
                expectedPrefab = i.MarkerPref;
                break;
            }
        }
        GameObject intersection = Instantiate(expectedPrefab, mark.Position, Quaternion.identity);
        //intersection.transform.parent = Camera.main.transform;
        intersection.GetComponent<InterseptionMark>().Power = mark.Power;
    }
}
