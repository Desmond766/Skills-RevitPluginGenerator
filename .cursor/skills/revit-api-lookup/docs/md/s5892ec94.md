---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointSetIterator.ReadPoints(System.IntPtr,System.Int32)
source: html/fc6673a0-7994-6d89-c267-cad26cf6dcd0.htm
---
# Autodesk.Revit.DB.PointClouds.IPointSetIterator.ReadPoints Method

Implement this method to fill the provided buffer with points up to the number of maximum points for
 which the buffer was allocated.

## Syntax (C#)
```csharp
int ReadPoints(
	IntPtr buffer,
	int bufferSize
)
```

## Parameters
- **buffer** (`System.IntPtr`) - Memory buffer into which the points should be written. The buffer was allocated
 by Revit and it is guaranteed to be valid for the duration of the call.
- **bufferSize** (`System.Int32`) - The maximum number of CloudPoint objects that may be copied into the buffer.

## Returns
The actual number of CloudPoint objects placed in the buffer (can be less than the
 length of the buffer). If there are no more points available, return 0.

