---
kind: method
id: M:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailHeight(System.Double)
source: html/58882b81-d58d-3a37-fd5a-4ba43bccc183.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailHeight Method

Checks whether the input height is valid for a non-continuous rail in its associated railing type.

## Syntax (C#)
```csharp
public bool IsValidNonContinuousRailHeight(
	double height
)
```

## Parameters
- **height** (`System.Double`) - The height to be checked.

## Returns
True if the height is smaller than the height of [!:Autodesk::Revit::DB::Architecture::RailingType] , false otherwise.

## Remarks
The height cannot be greater than the height of a [!:Autodesk::Revit::DB::Architecture::RailingType] 
 to which the non-continuous rail belongs.

