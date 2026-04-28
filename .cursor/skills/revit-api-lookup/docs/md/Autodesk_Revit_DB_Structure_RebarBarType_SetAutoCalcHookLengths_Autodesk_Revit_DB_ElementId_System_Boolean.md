---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetAutoCalcHookLengths(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/21dd89fe-8eac-3209-11f7-9c134f4ec9ef.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetAutoCalcHookLengths Method

Identifies if the hook lengths of a hook type are automatically calculated for this bar type

## Syntax (C#)
```csharp
public void SetAutoCalcHookLengths(
	ElementId hookId,
	bool autoCalculated
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type
- **autoCalculated** (`System.Boolean`) - True if the hook lengths should be automatically calculated, otherwise false
 When it is false, default hook length and default hook offset length will be reported

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

