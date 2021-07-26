using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene
{
    public class RayCast
    {
        //private void FindClosestHitByRay(Vector3 rayWorldCoordinates)
        //{
        //    AGameObject bestCandidate = null;
        //    double? bestDistance = null;
        //    foreach (var gameObject in _gameObjects)
        //    {
        //        if (!(gameObject is SelectableSphere) && !(gameObject is Asteroid))
        //            continue;
        //        var candidateDistance = gameObject.IntersectsRay(rayWorldCoordinates, _camera.Position);
        //        if (!candidateDistance.HasValue)
        //            continue;
        //        if (!bestDistance.HasValue)
        //        {
        //            bestDistance = candidateDistance;
        //            bestCandidate = gameObject;
        //            continue;
        //        }
        //        if (candidateDistance < bestDistance)
        //        {
        //            bestDistance = candidateDistance;
        //            bestCandidate = gameObject;
        //        }
        //    }
        //    if (bestCandidate != null)
        //    {
        //        switch (bestCandidate)
        //        {
        //            case Asteroid asteroid:
        //                _clicks += asteroid.Score;
        //                break;
        //            case SelectableSphere sphere:
        //                sphere.ToggleModel();
        //                break;
        //        }
        //    }
        //}

        //public double? IntersectsRay(Vector3 rayDirection, Vector3 rayOrigin)
        //{
        //    var radius = _scale.X;
        //    var difference = Position.Xyz - rayDirection;
        //    var differenceLengthSquared = difference.LengthSquared;
        //    var sphereRadiusSquared = radius * radius;
        //    if (differenceLengthSquared < sphereRadiusSquared)
        //    {
        //        return 0d;
        //    }
        //    var distanceAlongRay = Vector3.Dot(rayDirection, difference);
        //    if (distanceAlongRay < 0)
        //    {
        //        return null;
        //    }
        //    var dist = sphereRadiusSquared + distanceAlongRay * distanceAlongRay - differenceLengthSquared;
        //    var result = (dist < 0) ? null : distanceAlongRay - (double?)Math.Sqrt(dist);
        //    return result;
        //}
    }
}
