---
kind: method
id: M:Autodesk.Revit.DB.RevisionSettings.IsAcceptableRevisionCloudSpacing(System.Double)
source: html/32ba4971-4b3a-0e3b-4501-03f47599124b.htm
---
# Autodesk.Revit.DB.RevisionSettings.IsAcceptableRevisionCloudSpacing Method

Rounds the given raw value and checks whether it is an acceptable cloud spacing value after it is rounded.

## Syntax (C#)
```csharp
public bool IsAcceptableRevisionCloudSpacing(
	double rawValue
)
```

## Parameters
- **rawValue** (`System.Double`) - The raw value to check. This value need not be rounded prior to calling this function.

## Returns
True if the value will be acceptable after rounding, False otherwise

## Remarks
After rounding, the value must be a valid length that is greater than zero.

