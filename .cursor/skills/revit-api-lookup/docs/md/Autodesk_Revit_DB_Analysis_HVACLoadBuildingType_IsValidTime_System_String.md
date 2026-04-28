---
kind: method
id: M:Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.IsValidTime(System.String)
source: html/e367b4dc-a8b1-fc4b-6e7b-bfff3d7dd2c9.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.IsValidTime Method

Check if the string can be parsed to a valid time for opening time and closing time. A valid string can be "16:30" or "4:30 PM";

## Syntax (C#)
```csharp
public static bool IsValidTime(
	string hourMinute
)
```

## Parameters
- **hourMinute** (`System.String`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

