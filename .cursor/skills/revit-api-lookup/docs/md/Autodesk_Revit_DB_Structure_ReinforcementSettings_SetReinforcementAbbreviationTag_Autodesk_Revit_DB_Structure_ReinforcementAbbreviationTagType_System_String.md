---
kind: method
id: M:Autodesk.Revit.DB.Structure.ReinforcementSettings.SetReinforcementAbbreviationTag(Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTagType,System.String)
source: html/9907ed20-d7dd-f387-01e8-76f66f1c76f2.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.SetReinforcementAbbreviationTag Method

Sets one abbreviation tag for desired ReinforcementAbbreviationTagType.

## Syntax (C#)
```csharp
public void SetReinforcementAbbreviationTag(
	ReinforcementAbbreviationTagType tagType,
	string abbreviationTag
)
```

## Parameters
- **tagType** (`Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTagType`) - Defines the type of abbreviation tag.
- **abbreviationTag** (`System.String`) - Abbreviation tag value to set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The abbreviation type tagType is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

