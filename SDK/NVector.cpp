#include "Vector.h"

public ref class NVector {
private:
	Vector * vector;
public:
	NVector() { vector = new Vector(); };
	NVector(float x, float y, float z) { vector = new Vector(x, y, z); };
	~NVector() {};

#pragma region Properties
	property float x {
		float get() {
			return vector->x;
		}

		void set(float val) {
			vector->x = val;
		}
	}

	property float y {
		float get() {
			return vector->y;
		}

		void set(float val) {
			vector->y = val;
		}
	}

	property float z {
		float get() {
			return vector->z;
		}

		void set(float val) {
			vector->z = val;
		}
	}
#pragma endregion Properties

	NVector operator+=(NVector v) {
		vector->x += v.x;
		vector->y += v.y;
		vector->z += v.z;
		return ^this;
	}
};