---
kind: property
id: P:Autodesk.Revit.DB.InternalDefinition.Visible
source: html/c85900f4-8479-4760-c7b9-e316da571833.htm
---
# Autodesk.Revit.DB.InternalDefinition.Visible Property

Indicates if the parameter is visible in the Autodesk Revit user interface.

## Syntax (C#)
```csharp
public virtual bool Visible { get; }
```

## Remarks
The visible property controls whether a shared parameter is hidden from the user. This
is useful if you wish to add data to an element that is only meaningful to your application and
not to the user. This value can only be set when the shared parameter definition is created.

