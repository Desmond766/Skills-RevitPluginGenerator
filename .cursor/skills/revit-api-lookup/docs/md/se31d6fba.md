---
kind: property
id: P:Autodesk.Revit.DB.Opening.IsTransparentInElevation
source: html/459c0080-ccf3-41d8-9370-1f2df4042876.htm
---
# Autodesk.Revit.DB.Opening.IsTransparentInElevation Property

Indicates if the opening is transparent in elevation view when loaded into the project.

## Syntax (C#)
```csharp
public bool IsTransparentInElevation { get; set; }
```

## Remarks
This property is only valid in Revit family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when access this property in an opening belonging to a Revit project document.

