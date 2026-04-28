---
kind: property
id: P:Autodesk.Revit.DB.BasePoint.Clipped
source: html/e93c4d28-5bbc-9619-8313-fba01852a8bc.htm
---
# Autodesk.Revit.DB.BasePoint.Clipped Property

Clipped state of the survey point (shared BasePoint). Change its state to clipped or unclipped, depending on how you want to move the survey point.
 To move the survey coordinate system in relation to the model, move the clipped survey point.
 To change the survey point to another location in the survey coordinate system, move the unclipped survey point.
 For project base point (non-shared BasePoint), this property will always return false. Trying to set the property will get an InvalidOperationException.

## Syntax (C#)
```csharp
public bool Clipped { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation is only available for a shared BasePoint.

