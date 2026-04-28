---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.SunAndShadowType
source: html/0ea43c30-7953-b56e-9091-0e4524154b5e.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.SunAndShadowType Property

Identifies the type of the SunAndShadowSettings element.

## Syntax (C#)
```csharp
public SunAndShadowType SunAndShadowType { get; set; }
```

## Remarks
There are no restrictions on setting the type, but do note that some
 properties are not relevant for certain types. For example, the property
 EndDateAndTime is not relevant for the type SunAndShadowType.StillImage.
 In this example (and elsewhere), the previous value for the property
 is remembered for when the type is reverted. If that property has not been
 set yet, default values will apply.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

