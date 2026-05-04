---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.MoveAdaptiveComponentInstance(Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.Transform,System.Boolean)
source: html/088c995c-1d57-efd5-bc7f-7f9a193018aa.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.MoveAdaptiveComponentInstance Method

Moves Adaptive Component Instance by the specified transformation.

## Syntax (C#)
```csharp
public static void MoveAdaptiveComponentInstance(
	FamilyInstance famInst,
	Transform trf,
	bool unHost
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance
- **trf** (`Autodesk.Revit.DB.Transform`) - The Transformation
- **unHost** (`System.Boolean`) - True if the move should disassociate the Point Element Refs from their hosts.
 False if the Point Element Refs remain hosted.

## Remarks
This method will attempt a rigid body motion of all the individual references and hence
 the instance itself. However if unHost parameter is 'false' and any of the instance's
 references are hosted to any geometry, then those references will move within the constraints.
 The instance then adapts to where its references are moved to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - trf is not a rigid body transformation.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to move the adaptive component instance.

