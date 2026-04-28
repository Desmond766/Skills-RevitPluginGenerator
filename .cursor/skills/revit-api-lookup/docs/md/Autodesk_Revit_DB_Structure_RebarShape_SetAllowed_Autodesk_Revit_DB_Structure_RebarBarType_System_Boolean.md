---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.SetAllowed(Autodesk.Revit.DB.Structure.RebarBarType,System.Boolean)
source: html/5779735a-5105-127d-eaae-31fb0f2b81e4.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.SetAllowed Method

Specify which bar types can be used with this RebarShape. Bar types are allowed by default.

## Syntax (C#)
```csharp
public void SetAllowed(
	RebarBarType barType,
	bool allowed
)
```

## Parameters
- **barType** (`Autodesk.Revit.DB.Structure.RebarBarType`) - A bar type in the same document as this shape.
- **allowed** (`System.Boolean`) - Whether this shape may be combined with barType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

