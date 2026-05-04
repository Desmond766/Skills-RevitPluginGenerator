---
kind: property
id: P:Autodesk.Revit.DB.Leader.Elbow
zh: 管件、弯头、三通
source: html/e6414172-adb4-b3cb-4446-04f6be3c5b96.htm
---
# Autodesk.Revit.DB.Leader.Elbow Property

**中文**: 管件、弯头、三通

Elbow point of the Leader.

## Syntax (C#)
```csharp
public XYZ Elbow { get; set; }
```

## Remarks
This is the mid-point of the leader and its purpose depends on the
 shape of the leader. For arc-shaped leaders it defines the radius
 of the arc. For a kinked leader it divides the leader line and
 shoulder line. Note that straight-line leaders do not have an actual elbow; however,
 the value can still be obtained, although it will always equal the current
 anchor point. Consequently, an elbow point can be set even on a straight-line
 leader, but doing so will automatically change the leader's shape property. It is allowed to set the Elbow point of a kinked leader to equal either
 the end point or anchor point of the leader. Doing so will effectively
 change the leader's shape to a straight line. However, the elbow of an arc
 leader is never allowed to be placed on either the end or anchor point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A valid point must not be father then 10 miles (approx. 16 km) from the origin.
 -or-
 When setting this property: An arc leader may not have its Elbow point placed at the current position of the leader's Anchor or End point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The leader is not currently owned by a valid element. A probable reason for that
 could be if the element has been independently deleted, or the leader has never
 been properly initialized.

