---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.UpdateSpatialFieldPrimitive(System.Int32,Autodesk.Revit.DB.Analysis.FieldDomainPoints,Autodesk.Revit.DB.Analysis.FieldValues,System.Int32)
source: html/3559c556-e267-4af0-0fb5-45cafad35a30.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.UpdateSpatialFieldPrimitive Method

Populates analysis results data (or replaces the existing data) in the existing primitive identified by the unique index

## Syntax (C#)
```csharp
public void UpdateSpatialFieldPrimitive(
	int idx,
	FieldDomainPoints fieldDomainPoints,
	FieldValues fieldValues,
	int resultIndex
)
```

## Parameters
- **idx** (`System.Int32`) - Unique index identifying the primitive
- **fieldDomainPoints** (`Autodesk.Revit.DB.Analysis.FieldDomainPoints`) - Set of domain points.
 If the new set of domain points is supplied, all previously supplied domain points and field values for all results are removed from the primitive.
 If %fieldDomainPoints% is Nothing nullptr a null reference ( Nothing in Visual Basic) only fieldValues are updated
- **fieldValues** (`Autodesk.Revit.DB.Analysis.FieldValues`) - Set of data values.
 Number of values in fieldValues must coincide with the number of points in fieldDomainPoints
- **resultIndex** (`System.Int32`) - Unique index identifying the result schema

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - idx refers to non-existent primitive
 -or-
 fieldValues has incorrect number of measurements in ValueAtPoint objects
 -or-
 fieldDomainPoints has inconsistent type
 -or-
 resultIndex refers to non-existent result schema
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - fieldDomainPoints and fieldValues have inconsistent number of points

