---
kind: property
id: P:Autodesk.Revit.DB.GlobalParameter.IsReporting
source: html/41d62d48-8d78-d056-b0ca-9ea4777dc827.htm
---
# Autodesk.Revit.DB.GlobalParameter.IsReporting Property

Indicates whether this is a reporting global parameter or not.

## Syntax (C#)
```csharp
public bool IsReporting { get; set; }
```

## Remarks
When a global parameter is declared as reporting, it takes its value from
 the one driving dimension it is set to label. To be declared as reporting,
 a parameter must be labeling no more than one single-segment dimension. If a global parameter
 is not labeling any dimensions at the time it is declared as reporting,
 its value stays unchanged until a driving dimension is labeled with it. Reporting parameters can be (currently) only of type Length or Angle ,
 but programmers can always call the HasValidTypeForReporting () () () first
 when in doubt about whether a global parameter has a data type eligible for reporting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: This is a formula-driven parameter. As such it does not allow the current operation.
 -or-
 When setting this property: This non-reporting global parameter has already labeled other dimensions (more then 1).
 It cannot, therefore, be made reporting and dimension-driven before un-labeling all
 the dependent dimensions first.
 -or-
 When setting this property: The global parameter is not of a type that may be used with reporting.
 Generally, a reporting parameter must be either of type Length or Angle.
 -or-
 When setting this property: Currently reporting parameters may not be changed if they are driven by a dimension that cannot
 have its value set by a global parameter, such as an arc-length, locked, or multi-segment dimension.

