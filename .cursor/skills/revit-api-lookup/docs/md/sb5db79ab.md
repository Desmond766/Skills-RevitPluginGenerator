---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MEPSection.Flow
source: html/68589ece-8989-6b7c-d7da-a52c5a8b4672.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection.Flow Property

The flow of the section.

## Syntax (C#)
```csharp
public double Flow { get; }
```

## Remarks
In one section, all section members have same flow.
 Default unit is Cubic feet per second.
 For Duct, unit type is UT_HVAC_Airflow.
 For Pipe, unit type is UT_Piping_Flow

