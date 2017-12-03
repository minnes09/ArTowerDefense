using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTrackableEventHandler : DefaultTrackableEventHandler {

    //Activates the objects' components when it tracks the target
	protected override void OnTrackingFound()
	{
		base.OnTrackingFound();
		var terrainComponents = GetComponentsInChildren<Terrain> (true);
        var terrainColliderComponents = GetComponentsInChildren<TerrainCollider>(true);
        var meshRendererComponents = GetComponentsInChildren<MeshRenderer>(true);
        var meshColliderComponents = GetComponentsInChildren<MeshCollider>(true);
        // Enable terrains:
        foreach (var component in terrainComponents)
			component.enabled = true;
        foreach (var component in terrainColliderComponents)
            component.enabled = true;
        foreach (var component in meshRendererComponents)
            component.enabled = true;
        foreach (var component in meshColliderComponents)
            component.enabled = true;

        GameState.Instance().UnPause();
    }
    //Deactivates the objects' components when it tracks the target
    protected override void OnTrackingLost()
	{
        GameState.Instance().Pause();
        base.OnTrackingFound();
		var terrainComponents = GetComponentsInChildren<Terrain> (true);
        var terrainColliderComponents = GetComponentsInChildren<TerrainCollider>(true);
        var meshRendererComponents = GetComponentsInChildren<MeshRenderer>(true);
        var meshColliderComponents = GetComponentsInChildren<MeshCollider>(true);
        // Disable terrains:
        foreach (var component in terrainComponents)
			component.enabled = false;
        foreach (var component in terrainColliderComponents)
            component.enabled = false;
        foreach (var component in meshRendererComponents)
            component.enabled = false;
        foreach (var component in meshColliderComponents)
            component.enabled = false;
    }

	private void ToggleObjects(bool visible){
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);
		var terrainComponents = GetComponentsInChildren<Terrain> (true);
	}
}
