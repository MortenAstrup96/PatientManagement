export const minutesToTimespan = (minutes: number) => {
  const hrs = Math.floor(minutes / 60).toString().padStart(2, "0");
  const mins = (minutes % 60).toString().padStart(2, "0");
  return `${hrs}:${mins}:00`;
};