---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.GetHookTangentLength(Autodesk.Revit.DB.ElementId)
source: html/89dc8618-3109-4905-36b0-a8017044e651.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.GetHookTangentLength Method

Identifies the hook tangent length for a hook type

## Syntax (C#)
```csharp
public double GetHookTangentLength(
	ElementId hookId
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type

## Returns
The hook tangent length for a hook type

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

