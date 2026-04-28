---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.SetReleaseConditions(Autodesk.Revit.DB.Structure.ReleaseConditions)
source: html/79296d6b-51bd-d92c-ddb4-26689c76cc76.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SetReleaseConditions Method

Sets Release Conditions to Analytical Member.

## Syntax (C#)
```csharp
public void SetReleaseConditions(
	ReleaseConditions releaseConditions
)
```

## Parameters
- **releaseConditions** (`Autodesk.Revit.DB.Structure.ReleaseConditions`) - End to which release conditions will be added is defined by setting [!:Autodesk::Revit::DB::Structure::ReleaseConditions::Position] 
 property in provided release conditions object.

## Remarks
If element already have release conditions defined for that end, newly provided values replace current one.
 The ReleaseType will be set to UserDefined.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

