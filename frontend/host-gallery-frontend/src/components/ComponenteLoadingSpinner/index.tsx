import { LoadingSpinner } from "../LoadingSpinner";

export default function ComponenteLoadingSpinner() {
    return (
        <div className="fixed inset-0 flex items-center justify-center bg-gray-500 bg-opacity-50">
            <LoadingSpinner />
        </div>
    );
}
