---
kind: property
id: P:Autodesk.Revit.DB.Leader.End
source: html/6ad7af92-2a36-dd1e-6b98-3cb216f14da9.htm
---
# Autodesk.Revit.DB.Leader.End Property

End point of the Leader.

## Syntax (C#)
```csharp
public XYZ End { get; set; }
```

## Remarks
The End point is the leader's end that points to the object being annotated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A valid point must not be father then 10 miles (approx. 16 km) from the origin.
 -or-
 When setting this property: The leader's End point may not be placed at the current position of the Anchor or Elbow point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The leader is not currently owned by a valid element. A probable reason for that
 could be if the element has been independently deleted, or the leader has never
 been properly initialized.

