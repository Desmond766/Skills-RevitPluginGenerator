---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.IsAvailableIndex(System.Int32)
source: html/aa4c7c20-1e0c-39f3-1892-156fbc1fb2b9.htm
---
# Autodesk.Revit.DB.ElevationMarker.IsAvailableIndex Method

Returns true if a new elevation ViewSection can be placed at %index%, returns false otherwise.

## Syntax (C#)
```csharp
public bool IsAvailableIndex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the ElevationMarker which will be checked.

## Returns
True if an elevation can be created at %index%, false otherwise.

## Remarks
False will be returned if the %index% is already occupied or if %index% is out of range for the ElevationMarker.

