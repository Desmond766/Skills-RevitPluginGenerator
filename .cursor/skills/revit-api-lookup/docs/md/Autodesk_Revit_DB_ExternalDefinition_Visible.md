---
kind: property
id: P:Autodesk.Revit.DB.ExternalDefinition.Visible
source: html/a6f58bc8-b80d-a2f2-3081-a60495c3e741.htm
---
# Autodesk.Revit.DB.ExternalDefinition.Visible Property

Indicates if the parameter is visible in the Autodesk Revit user interface.

## Syntax (C#)
```csharp
public virtual bool Visible { get; }
```

## Remarks
The visible property controls whether a shared parameter is hidden from the user. This
is useful if you wish to add data to an element that is only meaningful to your application and
not to the user. This value can only be set when the shared parameter definition is created.

