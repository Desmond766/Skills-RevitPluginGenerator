---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.SetTransform(Autodesk.Revit.DB.Transform)
source: html/6e131a7a-8a41-04ba-cb9a-a1b50a0ddd18.htm
---
# Autodesk.Revit.DB.AssemblyInstance.SetTransform Method

Sets the origin of the assembly instance.

## Syntax (C#)
```csharp
public void SetTransform(
	Transform trf
)
```

## Parameters
- **trf** (`Autodesk.Revit.DB.Transform`) - Transform to be set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - trf is not a rigid body transformation.

