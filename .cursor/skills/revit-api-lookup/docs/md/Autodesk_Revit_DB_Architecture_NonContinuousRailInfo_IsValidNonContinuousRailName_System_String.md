---
kind: method
id: M:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailName(System.String)
source: html/605dd362-348c-1e39-02e4-dc3befec2eec.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidNonContinuousRailName Method

Checks whether the input name is valid for a non-continuous rail in its associated railing type.

## Syntax (C#)
```csharp
public bool IsValidNonContinuousRailName(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name to be checked.

## Returns
True if the name is unique for the [!:Autodesk::Revit::DB::Architecture::RailingType] , false otherwise.

## Remarks
The name must be unique within the [!:Autodesk::Revit::DB::Architecture::RailingType] 
 to which the non-continuous rail belongs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

