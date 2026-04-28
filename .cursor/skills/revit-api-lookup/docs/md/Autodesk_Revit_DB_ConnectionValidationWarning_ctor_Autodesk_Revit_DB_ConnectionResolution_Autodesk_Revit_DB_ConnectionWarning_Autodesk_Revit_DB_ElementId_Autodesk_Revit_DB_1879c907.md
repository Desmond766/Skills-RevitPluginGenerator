---
kind: method
id: M:Autodesk.Revit.DB.ConnectionValidationWarning.#ctor(Autodesk.Revit.DB.ConnectionResolution,Autodesk.Revit.DB.ConnectionWarning,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/8b3cf56b-b3fb-78d5-6375-9a08b42b2821.htm
---
# Autodesk.Revit.DB.ConnectionValidationWarning.#ctor Method

Constructor.

## Syntax (C#)
```csharp
public ConnectionValidationWarning(
	ConnectionResolution resolution,
	ConnectionWarning reason,
	ElementId part1,
	ElementId part2
)
```

## Parameters
- **resolution** (`Autodesk.Revit.DB.ConnectionResolution`) - Resolution type.
- **reason** (`Autodesk.Revit.DB.ConnectionWarning`) - Warning reason.
- **part1** (`Autodesk.Revit.DB.ElementId`) - First element Id.
- **part2** (`Autodesk.Revit.DB.ElementId`) - Second element Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

